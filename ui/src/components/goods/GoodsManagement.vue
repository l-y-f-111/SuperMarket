<template>
    <div>

        <div style="width:100%;display:flex;">
            <v-btn
                    prepend-icon="mdi-plus-circle"
                    class="mx-auto"
                    color="orange"
                    @click="router.push('/goods_editor/create')"
            >
                新增
            </v-btn>
            <v-btn
                    prepend-icon="mdi-delete"
                    class="mx-auto"
                    color="orange"
                    @click="selected_goods_ids=[]"
            >
                清除选中
            </v-btn>
            <v-btn
                    prepend-icon="mdi-delete"
                    class="mx-auto"
                    color="orange"
                    @click="delete_batch()"
            >
                删除选中
            </v-btn>
        </div>

        <v-divider class="my-4"/>

        <v-banner
                v-for="item in AllGoods"
                color="orange"
        >
            <v-banner-text style="font-size:20px">
                <v-checkbox
                        v-model="selected_goods_ids"
                        :label="item.GoodsName"
                        :value="Number(item.GoodsId)"
                />
                <v-chip
                        class="mr-3"
                        :text="'ID '+item.GoodsId.toString()"
                        color="orange"
                />
                <v-chip
                        class="mr-3"
                        :text="'库存 '+item.GoodsStock.toString()"
                        color="orange"
                />
                <v-chip
                        v-if="item.GoodsIsReady"
                        class="mr-3"
                        :text="'已上架'"
                        color="orange"
                />
            </v-banner-text>
            <template v-slot:actions>
                <v-btn
                        @click="router.push('/goods_editor/'+item.GoodsId)"
                >
                    修改
                </v-btn>
                <v-btn
                        @click="delete_single(item.GoodsId)"
                >
                    删除
                </v-btn>
            </template>
        </v-banner>

    </div>
</template>

<script lang="ts" setup>

import {GoodsRsp, getAllGoods} from "@/scripts/ws/goods/getAllGoods"
import {deleteGoods} from "@/scripts/ws/goods/deleteGoods"
import {useRouter} from "vue-router"
import FData from "@/components/field/f-data.vue"
import {onMounted, ref} from "vue"
import {deleteBatchGoods} from "@/scripts/ws/goods/deleteBatchGoods"

const router = useRouter()

async function delete_single(GoodsId: bigint) {
    await deleteGoods({GoodsId: GoodsId})
    AllGoods.value = (await getAllGoods({})).Collection
}

async function delete_batch() {
    await deleteBatchGoods({GoodsIds: selected_goods_ids.value})
    AllGoods.value = (await getAllGoods({})).Collection
}

const AllGoods = ref<GoodsRsp[]>([])
const selected_goods_ids = ref<number[]>([])

onMounted(async () => {
    AllGoods.value = (await getAllGoods({})).Collection
})

</script>

<style lang="stylus" scoped>

</style>