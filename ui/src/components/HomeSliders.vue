<template>
    <v-sheet
            class="mx-auto"
    >
        <v-slide-group
                class="pa-4"
                show-arrows
        >
            <v-slide-group-item
                    v-for="goods in shuffle_goods()"
                    v-slot="{ isSelected, toggle, selectedClass }"
            >
                <v-card
                        class="ma-4"
                        height="360"
                        width="360"
                        @click="()=>{if(IsUserLogin)router.push('/booking/' + goods.GoodsId)}"
                >
                    <v-img
                            :src="goods.GoodsCoverImg"
                    />
                </v-card>
            </v-slide-group-item>
        </v-slide-group>
    </v-sheet>
</template>

<script lang="ts" setup>
import {GoodsRsp} from "@/scripts/ws/goods/getAllGoods"

import {IsUserAdmin, IsUserLogin} from "@/scripts/state/user"
import {useRouter} from "vue-router"

const props = defineProps<{
    goods: GoodsRsp[]
}>()

const router = useRouter()

const shuffle_goods = () => props.goods.slice().sort(() => 0.5 - Math.random()).slice(0, 8)

</script>

<style lang="stylus" scoped>

</style>