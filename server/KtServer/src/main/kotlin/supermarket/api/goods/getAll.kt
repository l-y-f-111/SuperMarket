package supermarket.api.goods

import io.ktor.client.*
import io.ktor.client.engine.cio.*
import io.ktor.client.plugins.websocket.*
import io.ktor.http.*
import io.ktor.server.websocket.*
import io.ktor.websocket.*
import io.ktor.server.application.*
import io.ktor.server.routing.*
import kotlinx.coroutines.runBlocking
import supermarket.api.OLD_INFRA_WS_HOST
import supermarket.api.OLD_INFRA_WS_PORT

fun Application.getAll() {
    val client = HttpClient(CIO) {
        install(io.ktor.client.plugins.websocket.WebSockets)
    }

    routing {
        webSocket("/goods/get_all") {
            for (frame in incoming) {
                val msg = frame as Frame.Text
                runBlocking {
                    client.webSocket(
                        host = OLD_INFRA_WS_HOST,
                        port = OLD_INFRA_WS_PORT,
                        path = "/get_all_goods"
                    ) {
                        send(msg.readText())
                        outgoing.send(incoming.receive() as Frame.Text)
                    }
                }
                client.close()
            }
        }
    }
}
