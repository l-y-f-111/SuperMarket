import {wsUrlRoot} from "@/scripts/ws/meta"
import {createWebSocket, recvMsg, reqStringify, rspParse, sendMsg} from "@/scripts/ws/helper"

export {getAllGoods}
export type {
    GoodsRsp,
    GetAllGoodsReq,
    GetAllGoodsRsp
}

type GetAllGoodsReq =
    {}

type GoodsRsp =
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

type GetAllGoodsRsp =
    {
        Collection: GoodsRsp[]
    }

async function getAllGoods(req: GetAllGoodsReq) {
    const conn = createWebSocket(`${wsUrlRoot}/get_all_goods`)

    const task = recvMsg(conn)
    const reqJson = reqStringify(req)
    console.log('get_all_goods req:' + reqJson)
    sendMsg(conn, reqJson).then()
    const msg = await task
    console.log('get_all_goods rsp:' + msg)

    return <GetAllGoodsRsp>rspParse(msg)
}
