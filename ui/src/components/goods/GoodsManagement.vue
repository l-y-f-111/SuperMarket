<template>
  <div>

    <div style="width:100%;display:flex;">
      <v-btn
          prepend-icon="mdi-plus-circle"
          class="mx-auto"
          color="primary"
          @click="router.push('/goods_editor/create')"
      >
        新增
      </v-btn>
    </div>

    <v-divider class="my-4"/>

    <v-banner
        v-for="item in AllGoods"
        color="primary"
    >
      <v-banner-text style="font-size:20px">
        {{ item.GoodsName }}
      </v-banner-text>

      <template v-slot:actions>
        <v-btn
            @click="router.push('/goods_editor/'+item.GoodsId)"
        >
          修改
        </v-btn>
        <v-btn
            @click="delete_(item.GoodsId)"
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

const router = useRouter()

async function delete_(GoodsId: bigint) {
  await deleteGoods({GoodsId: GoodsId})
  AllGoods.value = (await getAllGoods({})).Collection
}

const AllGoods = ref<GoodsRsp[]>([])

onMounted(async () => {
  AllGoods.value = (await getAllGoods({})).Collection
})

</script>

<style lang="stylus" scoped>

</style>