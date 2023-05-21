<template>
    <div>

        <v-card>
            <v-card-title>
                商品编辑
            </v-card-title>
            <v-card-text>
                <v-text-field label="商品名" v-model="GoodsName"/>
                <v-text-field label="商品图片" v-model="GoodsCoverImg"/>
                <v-text-field label="商品介绍视频URL" v-model="GoodsPreviewVideoUrl"/>
                <v-combobox
                        v-model="GoodsTypes"
                        :items="[]"
                        label="商品类型"
                        multiple
                        chips
                />
                <v-text-field label="商品价格" v-model="GoodsPrice"/>

                <v-switch
                        label="上架"
                        color="orange"
                        v-model="GoodsIsReady"
                />
                <v-btn
                        v-if="!create_goods"
                        prepend-icon="mdi-content-save"
                        style="float:right"
                        color="orange"
                        class="mb-4"
                        @click="save()"
                >
                    保存
                </v-btn>
                <v-btn
                        v-else
                        prepend-icon="mdi-plus-circle"
                        style="float:right"
                        color="orange"
                        class="mb-4"
                        @click="save()"
                >
                    新增
                </v-btn>
            </v-card-text>
        </v-card>
    </div>
</template>

<script lang="ts" setup>

import {onMounted, ref} from "vue"
import {addGoods} from "@/scripts/ws/goods/addGoods"
import {updateGoods} from "@/scripts/ws/goods/updateGoods"
import {useRoute, useRouter} from "vue-router"
import {getGoods} from "@/scripts/ws/goods/getGoods"

const route = useRoute()
const router = useRouter()

const props = withDefaults(
    defineProps<{
        goods_id: bigint,
        create_goods: boolean,
    }>(), {
        create_goods: false
    })

const GoodsName = ref('商品名')
const GoodsCoverImg = ref('图片')
const GoodsPreviewVideoUrl = ref('介绍视频URL')
const GoodsPrice = ref(0)
const GoodsIsReady = ref(true)
const GoodsTypes = ref<string[]>([])
const GoodsStock = ref(0)

onMounted(async () => {
    if (!props.create_goods) {
        const goods = await getGoods({GoodsId: props.goods_id})
        GoodsName.value = goods.GoodsName
        GoodsCoverImg.value = goods.GoodsCoverImg
        GoodsPreviewVideoUrl.value = goods.GoodsPreviewVideoUrl
        GoodsPrice.value = goods.GoodsPrice
        GoodsIsReady.value = goods.GoodsIsReady
        GoodsTypes.value = goods.GoodsTypes
        GoodsStock.value = goods.GoodsStock
    }
})

async function save() {
    if (props.create_goods) {
        await addGoods({
            GoodsName: GoodsName.value,
            GoodsCoverImg: GoodsCoverImg.value,
            GoodsPreviewVideoUrl: GoodsPreviewVideoUrl.value,
            GoodsPrice: GoodsPrice.value,
            GoodsIsReady: GoodsIsReady.value,
            GoodsTypes: GoodsTypes.value,
            GoodsStock: GoodsStock.value
        })
    } else {
        await updateGoods({
            GoodsId: props.goods_id,
            GoodsName: GoodsName.value,
            GoodsCoverImg: GoodsCoverImg.value,
            GoodsPreviewVideoUrl: GoodsPreviewVideoUrl.value,
            GoodsPrice: GoodsPrice.value,
            GoodsIsReady: GoodsIsReady.value,
            GoodsTypes: GoodsTypes.value,
            GoodsStock: GoodsStock.value
        })
    }
    await router.push('/goods_management')
}

</script>

<style lang="stylus" scoped>

</style>