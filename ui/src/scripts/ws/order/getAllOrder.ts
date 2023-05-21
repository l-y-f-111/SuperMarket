import {wsUrlRoot} from "@/scripts/ws/meta"
import {createWebSocket, recvMsg, reqStringify, rspParse, sendMsg} from "@/scripts/ws/helper"

export {getAllOrder}
export type {
    OrderRsp,
    GetAllOrderReq,
    GetAllOrderRsp
}

type GetAllOrderReq =
    {}

type OrderRsp =
    {
        OrderId: bigint
        OrderUserId: bigint
        OrderGoodsId: bigint
        OrderTime: Date
        OrderPayAmount: number
        OrderStatus: string
    }

type GetAllOrderRsp =
    {
        Collection: OrderRsp[]
    }

async function getAllOrder(req: GetAllOrderReq) {
    const conn = createWebSocket(`${wsUrlRoot}/order/get_all`)

    const task = recvMsg(conn)
    const reqJson = reqStringify(req)
    console.log('get_all_order req:' + reqJson)
    sendMsg(conn, reqJson).then()
    const msg = await task
    console.log('get_all_order rsp:' + msg)

    return <GetAllOrderRsp>rspParse(msg)
}