package supermarket

import io.ktor.server.application.*
import io.ktor.server.engine.*
import io.ktor.server.netty.*
import io.ktor.server.websocket.*
import org.ktorm.database.Database
import java.time.Duration

// goods
import supermarket.api.goods.add as goodsAdd
import supermarket.api.goods.delete as goodsDelete
import supermarket.api.goods.deleteBatch as goodsDeleteBatch
import supermarket.api.goods.get as goodsGet
import supermarket.api.goods.getAll as goodsGetAll
import supermarket.api.goods.getAllType as goodsGetAllType
import supermarket.api.goods.search as goodsSearch
import supermarket.api.goods.update as goodsUpdate
// order
import supermarket.api.order.add as orderAdd
import supermarket.api.order.get as orderGet
import supermarket.api.order.getAll as orderGetAll
import supermarket.api.order.getAllWithUserId as orderGetAllWithUserId
import supermarket.api.order.isIdValid as orderIsIdValid
import supermarket.api.order.refund as orderRefund
// user
import supermarket.api.user.add as userAdd
import supermarket.api.user.get as userGet
import supermarket.api.user.getVipLevel as userGetVipLevel
import supermarket.api.user.isIdMatchPwd as userIsIdMatchPwd
import supermarket.api.user.refundVip as userRefundVip
import supermarket.api.user.resetPwd as userResetPwd
import supermarket.api.user.upgradeVip as userUpgradeVip

const val WS_HOST = "localhost"
const val WS_PORT = 11452

const val DB_SCHEMA = "super_market"
const val DB_USER = "postgres"
const val DB_PWD = "65a1561425f744e2b541303f628963f8"

fun main() {
    embeddedServer(Netty, port = WS_PORT, host = WS_HOST, module = Application::module)
        .start(wait = true)
}

fun Application.module() {
    install(WebSockets) {
        pingPeriod = Duration.ofSeconds(10)
        timeout = Duration.ofSeconds(10)
        maxFrameSize = Long.MAX_VALUE
        masking = false
    }

    val db = Database.connect(
        url = "jdbc:postgresql://localhost:5432/$DB_SCHEMA",
        driver = "org.postgresql.Driver",
        user = DB_USER,
        password = DB_PWD
    )

    // goods
    goodsAdd()
    goodsDelete()
    goodsDeleteBatch(db)
    goodsGet()
    goodsGetAll()
    goodsGetAllType()
    goodsSearch()
    goodsUpdate()

    // order
    orderAdd()
    orderGet()
    orderGetAll()
    orderGetAllWithUserId()
    orderIsIdValid()
    orderRefund()

    // user
    userAdd()
    userGet()
    userGetVipLevel()
    userIsIdMatchPwd()
    userRefundVip()
    userResetPwd()
    userUpgradeVip()
}