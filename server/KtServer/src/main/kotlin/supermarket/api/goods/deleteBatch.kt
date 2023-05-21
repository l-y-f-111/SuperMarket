package supermarket.api.goods

import io.ktor.server.websocket.*
import io.ktor.websocket.*
import io.ktor.server.application.*
import io.ktor.server.routing.*
import kotlinx.serialization.Serializable
import kotlinx.serialization.decodeFromString
import kotlinx.serialization.encodeToString
import kotlinx.serialization.json.Json
import org.ktorm.database.Database
import org.ktorm.dsl.*
import supermarket.db.public.GoodsTable

@Serializable
private data class Rsp(val Ok: Boolean)

@Serializable
private data class Req(val GoodsIds: List<Long>)

private fun goodsCheck(db: Database, userIdsToCheck: List<Long>): Boolean {
    val query = db.from(GoodsTable).select().where(GoodsTable.goods_id inList userIdsToCheck)
    val results = query.map { it[GoodsTable.goods_id] }
    return results.size == userIdsToCheck.size
}

private fun goodsDelete(db: Database, userIdsToDelete: List<Long>): Int {
    return db.delete(GoodsTable) { it.goods_id inList userIdsToDelete }
}

fun Application.deleteBatch(db:Database) {
    routing {
        webSocket("/goods/delete_batch") {
            for (frame in incoming) {
                if (frame is Frame.Text) {
                    val req = Json.decodeFromString<Req>(frame.readText())
                    if (req.GoodsIds.isEmpty()) { //判断是否为空列表
                        outgoing.send(Frame.Text(Json.encodeToString(Rsp(true))))
                    } else {
                        if (goodsCheck(db, req.GoodsIds)) { //判断数据是否不合法
                            //判断删除是否失败
                            val rsp = Rsp(goodsDelete(db, req.GoodsIds) >= 0)
                            outgoing.send(Frame.Text(Json.encodeToString(rsp)))
                        } else {
                            val rsp = Rsp(false)
                            outgoing.send(Frame.Text(Json.encodeToString(rsp)))
                        }
                    }
                }
            }
        }
    }
}

