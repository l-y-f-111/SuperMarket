<template>
  <div>

    <h2>{{ GoodsName }} 订单编辑</h2>

    <v-divider class="my-4"></v-divider>
    <div class="footage">
      <v-chip
          class="discount_message"
          color="orange"
      >
        您是会员Level {{ UserVipLevel }}用户，已享受{{ UserVipDiscount * 10 }}折优惠
      </v-chip>

      <v-chip
          color="red"
          size="large"
          class="pay_price"
          v-if="UserVipDiscount<1"
      >
        <strike>原价 {{ GoodsPrice }} 元</strike>
      </v-chip>
      <v-chip
          color="green"
          size="large"
          class="pay_price"
      >
        实付 {{ UserVipDiscount * GoodsPrice }} 元
      </v-chip>

      <v-btn
          class="pay-btn"
          color="orange"
          @click="create()"
      >
        创建订单
      </v-btn>
    </div>
  </div>
</template>

<script lang="ts" setup>

import {useRouter} from "vue-router"
import {UserVipDiscount, UserId, UserVipLevel} from "@/scripts/state/user"

const props =
    defineProps<{
      goodsId: bigint
    }>()

const GoodsName = ref('')
const GoodsPrice = ref(0.0)

import {onMounted, Ref, ref, watch} from "vue"
import {getGoods} from "@/scripts/ws/goods/getGoods"
import {addOrder} from "@/scripts/ws/order/addOrder"
import {HTMLCanvasElementLuminanceSource} from "html5-qrcode/third_party/zxing-js.umd"
import {utf8_to_b64} from "@/scripts/ws/helper"

const router = useRouter()

function sqrt(x: number) {
  return Math.sqrt(x)
}

onMounted(async () => {
  const goods = await getGoods({GoodsId: props.goodsId})
  GoodsName.value = goods.GoodsName
  GoodsPrice.value = goods.GoodsPrice
})

const selected_seat_col_row =
    ref<[number, number]>([0, 0])

function selectedSeat() {
  return `${selected_seat_col_row.value[1]}排${selected_seat_col_row.value[0]}列`
}

const seats_row_cols =
    ref<[number, number][]>([
      [1, 9],
      [2, 10],
      [3, 11],
      [4, 12],
      [5, 13],
      [6, 14],
      [7, 15],
      [8, 16],
      [9, 17],
      [10, 18],
      [11, 19],
      [12, 20]
    ])

async function create() {
    const order = (await addOrder({
        OrderGoodsId: props.goodsId,
        OrderUserId: UserId.value,
        OrderPayAmount: UserVipDiscount.value * GoodsPrice.value
    }))
    if (order.Ok) {
        await router.push('/pay_success/' + order.OrderId + '/' + utf8_to_b64(order.AlipayQrCodePath))
    }
}
</script>

<style lang="stylus" scoped>

.seats
  width 100%

.screen_chip_holder
  width 100%
  display flex
  justify-content center

.screen_chip
  margin-left auto
  margin-right auto

.seats_col
  width fit-content
  margin-left auto
  margin-right auto

.footage
  display flex
  justify-content end

.discount_message
  margin-right auto

.pay_price
  font-weight 600
  margin-right 10px

.pay-btn
  width 20%

</style>