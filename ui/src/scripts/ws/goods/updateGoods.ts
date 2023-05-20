import {wsUrlRoot} from "@/scripts/ws/meta"
import {createWebSocket, recvMsg, reqStringify, rspParse, sendMsg} from "@/scripts/ws/helper"

export {updateGoods}
export type {
    UpdateGoodsReq,
    UpdateGoodsRsp
}

type UpdateGoodsReq =
    {
        GoodsId: bigint
        GoodsName: string
        GoodsCoverImg: string
        GoodsPreviewVideoUrl: string
        GoodsPrice: number
        GoodsIsReady: boolean
        GoodsTypes: string[]
        GoodsStock: number
    }

type UpdateGoodsRsp =
    {
        Ok: boolean
    }

async function updateGoods(req: UpdateGoodsReq) {
    const conn = createWebSocket(`${wsUrlRoot}/update_goods`)

    const task = recvMsg(conn)
    const reqJson = reqStringify(req)
    console.log('update_goods req:' + reqJson)
    sendMsg(conn, reqJson).then()
    const msg = await task
    console.log('update_goods rsp:' + msg)

    return <UpdateGoodsRsp>rspParse(msg)
}