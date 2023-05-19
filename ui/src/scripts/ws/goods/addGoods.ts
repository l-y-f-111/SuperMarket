import {wsUrlRoot} from "@/scripts/ws/meta"
import {createWebSocket, recvMsg, reqStringify, rspParse, sendMsg} from "@/scripts/ws/helper"

export {addGoods}
export type {
    AddGoodsReq,
    AddGoodsRsp
}

type  AddGoodsReq =
    {
        GoodsName: string
        GoodsCoverImg: string
        GoodsPreviewVideoUrl: string
        GoodsPrice: number
        GoodsIsPreorder: boolean
        GoodsTypes: string[]
    }

type AddGoodsRsp =
    {
        Ok: boolean
        GoodsId: bigint
    }

async function addGoods(req: AddGoodsReq) {
    const conn = createWebSocket(`${wsUrlRoot}/add_goods`)

    const task = recvMsg(conn)
    const reqJson = reqStringify(req)
    console.log('add_goods req:' + reqJson)
    sendMsg(conn, reqJson).then()
    const msg = await task
    console.log('add_goods rsp:' + msg)

    return <AddGoodsRsp>rspParse(msg)
}