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

const wsUrlRoot = "ws://localhost:11452"

async function deleteBatchGoods(req: DeleteBatchGoodsReq) {
    // @ts-ignore
    const conn = createWebSocket(`${wsUrlRoot}/goods/delete_batch`)

    const task = recvMsg(conn)
    const reqJson = reqStringify(req)
    console.log('delete_batch_goods req:' + reqJson)
    sendMsg(conn, reqJson).then()
    const msg = await task
    console.log('delete_batch_goods rsp:' + msg)

    return <DeleteBatchGoodsRsp>rspParse(msg)
}
