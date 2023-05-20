import {wsUrlRoot} from "@/scripts/ws/meta"
import {createWebSocket, recvMsg, reqStringify, rspParse, sendMsg} from "@/scripts/ws/helper"

export {getGoods}
export type {
    GetGoodsReq,
    GetGoodsRsp
}

type GetGoodsReq =
    {
        GoodsId: bigint
    }

type GetGoodsRsp =
    {
        Ok: boolean
        GoodsName: string
        GoodsCoverImg: string
        GoodsPreviewVideoUrl: string
        GoodsPrice: number
        GoodsIsReady: boolean
        GoodsTypes: string[]
        GoodsStock: number
    }

async function getGoods(req: GetGoodsReq) {
    const conn = createWebSocket(`${wsUrlRoot}/get_goods`)

    const task = recvMsg(conn)
    const reqJson = reqStringify(req)
    console.log('get_goods req:' + reqJson)
    sendMsg(conn, reqJson).then()
    const msg = await task
    console.log('get_goods rsp:' + msg)

    return <GetGoodsRsp>rspParse(msg)
}
