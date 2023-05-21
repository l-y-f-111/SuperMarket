import {wsUrlRoot} from "@/scripts/ws/meta"
import {createWebSocket, recvMsg, reqStringify, rspParse, sendMsg} from "@/scripts/ws/helper"

export {deleteGoods}
export type {
    DeleteGoodsReq,
    DeleteGoodsRsp
}

type DeleteGoodsReq =
    {
        GoodsId: bigint
    }

type DeleteGoodsRsp =
    {
        Ok: boolean
    }

async function deleteGoods(req: DeleteGoodsReq) {
    const conn = createWebSocket(`${wsUrlRoot}/goods/delete`)

    const task = recvMsg(conn)
    const reqJson = reqStringify(req)
    console.log('delete_goods req:' + reqJson)
    sendMsg(conn, reqJson).then()
    const msg = await task
    console.log('delete_goods rsp:' + msg)

    return <DeleteGoodsRsp>rspParse(msg)
}