import {wsUrlRoot} from "@/scripts/ws/meta"
import {createWebSocket, recvMsg, reqStringify, rspParse, sendMsg} from "@/scripts/ws/helper"

export {deleteBatchGoods}
export type {
    DeleteGoodsReq,
    DeleteGoodsRsp
}

type DeleteGoodsReq =
    {
        GoodsIds: bigint[]
    }

type DeleteGoodsRsp =
    {
        Ok: boolean
    }

async function deleteBatchGoods(req: DeleteGoodsReq) {
    const conn = createWebSocket(`${wsUrlRoot}/delete_batch_goods`)

    const task = recvMsg(conn)
    const reqJson = reqStringify(req)
    console.log('delete_batch_goods req:' + reqJson)
    sendMsg(conn, reqJson).then()
    const msg = await task
    console.log('delete_batch_goods rsp:' + msg)

    return <DeleteGoodsRsp>rspParse(msg)
}
