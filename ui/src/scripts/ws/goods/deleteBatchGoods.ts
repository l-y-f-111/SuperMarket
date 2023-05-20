import {createWebSocket, recvMsg, reqStringify, rspParse, sendMsg} from "@/scripts/ws/helper"

export {deleteBatchGoods}
export type {
    DeleteBatchGoodsReq,
    DeleteBatchGoodsRsp
}

type DeleteBatchGoodsReq =
    {
        GoodsIds: number[]
    }

type DeleteBatchGoodsRsp =
    {
        Ok: boolean
    }


// HACK
const wsUrlRoot = "ws://localhost:11452"

async function deleteBatchGoods(req: DeleteBatchGoodsReq) {
    const conn = createWebSocket(`${wsUrlRoot}/delete_batch_goods`)

    const task = recvMsg(conn)
    const reqJson = reqStringify(req)
    console.log('delete_batch_goods req:' + reqJson)
    sendMsg(conn, reqJson).then()
    const msg = await task
    console.log('delete_batch_goods rsp:' + msg)

    return <DeleteBatchGoodsRsp>rspParse(msg)
}
