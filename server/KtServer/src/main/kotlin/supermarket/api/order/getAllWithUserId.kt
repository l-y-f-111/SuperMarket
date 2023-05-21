package supermarket.api.order

import io.ktor.client.*
import io.ktor.client.plugins.websocket.*
import io.ktor.http.*
import io.ktor.server.websocket.*
import io.ktor.websocket.*
import io.ktor.server.application.*
import io.ktor.server.routing.*
import supermarket.api.OLD_INFRA_WS_HOST
import supermarket.api.OLD_INFRA_WS_PORT

fun Application.getAllWithUserId() {
    val client = HttpClient {
        install(io.ktor.client.plugins.websocket.WebSockets)
    }

    routing {
        webSocket("/order/get_all_with_user_id") {
            for (frame in incoming) {
                val msg = frame as Frame.Text
                client.webSocket(
                    method = HttpMethod.Get,
                    host = OLD_INFRA_WS_HOST,
                    port = OLD_INFRA_WS_PORT,
                    path = "/get_all_order_with_user_id"
                ) {
                    send(msg.readText())
                    outgoing.send(incoming.receive() as Frame.Text)
                }
            }
        }
    }
}
