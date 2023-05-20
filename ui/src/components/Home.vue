<template>
    <div class="home_zone">
        <HomeSliders :goods="ready_goods_list"/>

        <v-card variant="text">
            <template v-slot:title>
                <v-chip color="orange" size="x-large">
                    <h2 style="font-weight:400">
                        热销商品
                    </h2>
                </v-chip>
            </template>

            <v-card-text class="card_field">
                <GoodsPreviewCard
                        v-for="goods in ready_goods_list"
                        :cover_img="goods.GoodsCoverImg"
                        :name="goods.GoodsName"
                        :stock="goods.GoodsStock"
                        :price="goods.GoodsPrice"
                        :booking_route="'booking/'+goods.GoodsId"
                        :pv_url="goods.GoodsPreviewVideoUrl"
                />
            </v-card-text>

        </v-card>

    </div>
</template>

<script lang="ts" setup>

import {onMounted, ref} from "vue"
import GoodsPreviewCard from "@/components/goods/GoodsPreviewCard.vue"
import {GoodsRsp, getAllGoods, GetAllGoodsReq} from "@/scripts/ws/goods/getAllGoods"
import {useRouter} from "vue-router"
import HomeSliders from "@/components/HomeSliders.vue"

const router = useRouter()
let req = <GetAllGoodsReq>{
    CinemaName: "hi"
}

const ready_goods_list = ref<GoodsRsp[]>([])

onMounted(async () => {
    const all_goods_list = (await getAllGoods({})).Collection

    for (const goods of all_goods_list) {
        if (goods.GoodsIsReady)
            ready_goods_list.value.push(goods)
    }

})

</script>

<style lang="stylus" scoped>

.home_zone
  margin-left 30px
  margin-right 30px

.card_field
  display flex
  flex-wrap wrap
  justify-content center

</style>