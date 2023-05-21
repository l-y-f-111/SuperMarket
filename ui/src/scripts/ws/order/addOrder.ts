import {wsUrlRoot} from "@/scripts/ws/meta"
import {createWebSocket, recvMsg, reqStringify, rspParse, sendMsg} from "@/scripts/ws/helper"

export {addOrder}
export type {
    AddOrderReq,
    AddOrderRsp
}

type AddOrderReq =
    {
        OrderGoodsId: bigint
        OrderUserId: bigint
        OrderPayAmount: number
    }

type AddOrderRsp =
    {
        Ok: boolean
        OrderId: bigint
        AlipayQrCodePath: string
    }

async function addOrder(req: AddOrderReq) {
    const conn = createWebSocket(`${wsUrlRoot}/order/add`)

    const task = recvMsg(conn)
    const reqJson = reqStringify(req)
    console.log('add_order req:' + reqJson)
    sendMsg(conn, reqJson).then()
    const msg = await task
    console.log('add_order rsp:' + msg)

    return <AddOrderRsp>rspParse(msg)
}