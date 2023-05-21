package supermarket.api.user

import io.ktor.client.*
import io.ktor.client.plugins.websocket.*
import io.ktor.http.*
import io.ktor.server.websocket.*
import io.ktor.websocket.*
import io.ktor.server.application.*
import io.ktor.server.routing.*
import supermarket.api.OLD_INFRA_WS_HOST
import supermarket.api.OLD_INFRA_WS_PORT

fun Application.isIdMatchPwd() {
    val client = HttpClient {
        install(io.ktor.client.plugins.websocket.WebSockets)
    }

    routing {
        webSocket("/user/is_id_match_pwd") {
            for (frame in incoming) {
                val msg = frame as Frame.Text
                client.webSocket(
                    method = HttpMethod.Get,
                    host = OLD_INFRA_WS_HOST,
                    port = OLD_INFRA_WS_PORT,
                    path = "/is_user_id_match_pwd"
                ) {
                    send(msg.readText())
                    outgoing.send(incoming.receive() as Frame.Text)
                }
            }
        }
    }
}
