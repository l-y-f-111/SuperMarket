<template>
  <div class="home_zone">
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
            v-for="goods in released_goods_list"
            :cover_img="goods.GoodsCoverImg"
            :name="goods.GoodsName"
            :booking_route="'booking/'+goods.GoodsId"
            :trailer_url="goods.GoodsPreviewVideoUrl"
        />
      </v-card-text>

    </v-card>
    <v-card variant="text" class="mt-5">
      <template v-slot:title>
        <v-chip color="blue" size="x-large">
          <h2 style="font-weight:400">
            预售中
          </h2>
        </v-chip>
      </template>

      <v-card-text class="card_field">
        <GoodsPreviewCard
            v-for="goods in preview_goods_list"
            :cover_img="goods.GoodsCoverImg"
            :name="goods.GoodsName"
            :booking_route="'booking/'+goods.GoodsId"
            :trailer_url="goods.GoodsPreviewVideoUrl"
        />
      </v-card-text>
    </v-card>

  </div>
</template>

<script lang="ts" setup>

import {onMounted, ref} from "vue"
import GoodsPreviewCard from "@/components/goods/GoodsPreviewCard.vue"
import {
  goods_on_show_list,
  goods_preview_list
} from "@/scripts/goods_data"
import {GoodsRsp, getAllGoods, GetAllGoodsReq} from "@/scripts/ws/goods/getAllGoods"
import {useRouter} from "vue-router"

const router = useRouter()
let req = <GetAllGoodsReq>{
  CinemaName: "hi"
}

const released_goods_list = ref<GoodsRsp[]>([])
const preview_goods_list = ref<GoodsRsp[]>([])

onMounted(async () => {
  const all_goods_list = (await getAllGoods({})).Collection

  for (const goods of all_goods_list) {
    if (goods.GoodsIsPreorder)
      preview_goods_list.value.push(goods)
    else
      released_goods_list.value.push(goods)
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