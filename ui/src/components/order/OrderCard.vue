<template>

  <v-card class="mt-2">
    <v-card-title>
      <v-chip variant="text">订单号 {{ order_id }}</v-chip>
      <v-chip color="primary">
        订单状态 {{ OrderStatus }}
      </v-chip>
    </v-card-title>
    <v-card-text>
      <v-chip class="mx-2 mt-2">
        用户 {{ user_id }}
      </v-chip>
      <v-chip class="mx-2 mt-2">
        支付金额 {{ pay_amount }}
      </v-chip>
      <v-chip class="mx-2 mt-2">
        订单时间 {{ order_time.toString() }}
      </v-chip>
      <v-chip class="mx-2 mt-2">
        商品名称 {{ GoodsName }}
      </v-chip>
    </v-card-text>
    <v-card-actions>
      <v-btn
          class="mx-4" color="primary"
          prepend-icon="mdi-printer"
          @click="router.push('/ticket_printing/'+order_id)"
      >
        凭据
      </v-btn>
      <v-btn class="mx-4" color="primary"
             v-if="IsUserAdmin"
             @click="refund(order_id)"
      >
        退款
      </v-btn>
    </v-card-actions>
  </v-card>

</template>

<script lang="ts" setup>

import {useRouter} from "vue-router"
import {IsUserAdmin} from "@/scripts/state/user"
import {onMounted, ref} from "vue"
import {getAllOrderWithUserId} from "@/scripts/ws/order/getAllOrderWithUserId"
import {getGoods} from "@/scripts/ws/goods/getGoods"
import {getOrder} from "@/scripts/ws/order/getOrder"
import {refundOrder} from "@/scripts/ws/order/refundOrder"

const router = useRouter()

const emits = defineEmits<{
  (e: 'refund'): void
}>()

const props =
    defineProps<{
      order_id: bigint,
      user_id: bigint,
      pay_amount: number,
      order_time: Date,
      goods_id: bigint,
    }>()

const OrderStatus = ref('')
const GoodsName = ref('')

onMounted(async () => {
  GoodsName.value = (await getGoods({GoodsId: props.goods_id})).GoodsName
  const order = await getOrder({OrderId: props.order_id})
  OrderStatus.value = order.OrderStatus
})


async function refund(order_id: bigint) {
  const rsp = await refundOrder({OrderId: order_id})
  if (rsp.Ok) {
    emits('refund')
  }
  GoodsName.value = (await getGoods({GoodsId: props.goods_id})).GoodsName
  const order = await getOrder({OrderId: props.order_id})
  OrderStatus.value = order.OrderStatus
}

</script>

<style lang="stylus" scoped>

</style>