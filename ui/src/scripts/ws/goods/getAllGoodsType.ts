import {wsUrlRoot} from "@/scripts/ws/meta"
import {createWebSocket, recvMsg, reqStringify, rspParse, sendMsg} from "@/scripts/ws/helper"

export {getAllGoodsType}
export type {
    GetAllGoodsTypeReq,
    GetAllGoodsTypeRsp
}

type GetAllGoodsTypeReq =
    {}

type GetAllGoodsTypeRsp =
    {
        Collection: string[]
    }

async function getAllGoodsType(req: GetAllGoodsTypeReq) {
    const conn = createWebSocket(`${wsUrlRoot}/get_all_goods_type`)

    const task = recvMsg(conn)
    const reqJson = reqStringify(req)
    console.log('get_all_goods_type req:' + reqJson)
    sendMsg(conn, reqJson).then()
    const msg = await task
    console.log('get_all_goods_type rsp:' + msg)

    return <GetAllGoodsTypeRsp>rspParse(msg)
}
