import {GoodsRsp} from "@/scripts/ws/goods/getAllGoods"
import {wsUrlRoot} from "@/scripts/ws/meta"
import {createWebSocket, recvMsg, reqStringify, rspParse, sendMsg} from "@/scripts/ws/helper"

export {searchGoods}
export type {
    SearchGoodsReq,
    SearchGoodsRsp
}

type SearchGoodsReq =
    {
        GoodsTypes: string[]
        GoodsNameKeyWord: string
    }

type SearchGoodsRsp =
    {
        Collection: GoodsRsp[]
    }

async function searchGoods(req: SearchGoodsReq) {
    const conn = createWebSocket(`${wsUrlRoot}/search_goods`)

    const task = recvMsg(conn)
    const reqJson = reqStringify(req)
    console.log('search_goods req:' + reqJson)
    sendMsg(conn, reqJson).then()
    const msg = await task
    console.log('search_goods rsp:' + msg)

    return <SearchGoodsRsp>rspParse(msg)
}