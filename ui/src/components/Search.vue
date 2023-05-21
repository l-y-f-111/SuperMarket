<template>
    <div class="mt-5">

        <v-autocomplete
                :items="AllGoodsType"
                v-model="SelectedGoodsType"
                outlined
                dense
                chips
                small-chips
                label="类型"
                multiple
        />

        <v-text-field label="商品名关键词"
                      v-model="GoodsNameKeyWord"/>

        <div style="display:flex">
            <v-btn
                    class="search_btn"
                    color="orange"
                    @click="search()"
            >
                查询
            </v-btn>
        </div>

        <div class="card_field" v-if="search_result.length!==0">
            <GoodsPreviewCard
                    v-for="goods in search_result"
                    :cover_img="goods.GoodsCoverImg"
                    :name="goods.GoodsName"
                    :price="goods.GoodsPrice"
                    :booking_route="'booking/'+goods.GoodsId"
                    :pv_url="goods.GoodsPreviewVideoUrl"
            />
        </div>

    </div>
</template>

<script lang="ts" setup>

import {onMounted, Ref, ref, watch} from "vue"
import GoodsPreviewCard from "@/components/goods/GoodsPreviewCard.vue"
import {searchGoods} from "@/scripts/ws/goods/searchGoods"
import {useRouter} from "vue-router"
import {GoodsRsp} from "@/scripts/ws/goods/getAllGoods"
import {getAllGoodsType} from "@/scripts/ws/goods/getAllGoodsType"

const router = useRouter()

const AllGoodsType = ref(['全部'])
const SelectedGoodsType = ref(['全部'])

const GoodsNameKeyWord = ref('')
const EnableScheduleSearch = ref(false)

function handler(x: string[], target: Ref<string[]>) {
    if (x.length === 0)
        target.value = ['全部']
    if (x.length > 1 && target.value.find(y => y === '全部')) {
        target.value = target.value.filter(x => x !== '全部')
    }
}

watch(SelectedGoodsType, x => handler(x, SelectedGoodsType))

const search_result = ref<GoodsRsp[]>([])

async function search() {
    //TODO 校验
    search_result.value = (await searchGoods({
        GoodsTypes: (SelectedGoodsType.value.some(x => x === "全部") ?
            [''] : SelectedGoodsType.value),
        GoodsNameKeyWord: GoodsNameKeyWord.value
    })).Collection

}

onMounted(async () => {
    AllGoodsType.value = (await getAllGoodsType({})).Collection
    AllGoodsType.value.push('全部')
    search()
})

</script>

<style lang="stylus" scoped>

.search_btn
  width: 200px
  margin-left auto
  margin-right auto

.card_field
  margin-top 50px
  display flex
  flex-wrap wrap
  justify-content space-around

.movie_card
  width 20%

</style>
