<template>

  <OrderCard
      class="mb-2"
      v-for="order in UserOrders"

      :order_id="order.OrderId"
      :user_id="order.OrderUserId"
      :pay_amount="order.OrderPayAmount"
      :order_time="order.OrderTime"
      :goods_id="order.OrderGoodsId"
      @refund="reload()"
  />

</template>

<script lang="ts" setup>

import {onMounted, ref} from "vue"
import OrderCard from "@/components/order/OrderCard.vue"
import {useRouter} from "vue-router"
import {OrderRsp} from "@/scripts/ws/order/getAllOrder"
import {getAllOrderWithUserId} from "@/scripts/ws/order/getAllOrderWithUserId"
import {getAllOrder} from "@/scripts/ws/order/getAllOrder"

const router = useRouter()

const props =
    defineProps<{
      user_id: bigint
    }>()

const UserOrders = ref<OrderRsp[]>([])

async function reload() {
  if (props.user_id < 1000n) {
    UserOrders.value =
        (await getAllOrder({})).Collection
  } else {
    UserOrders.value =
        (await getAllOrderWithUserId({
          OrderUserId: props.user_id
        })).Collection
  }
}


onMounted(async () => {
  await reload()
})

</script>

<style lang="stylus" scoped>

</style>