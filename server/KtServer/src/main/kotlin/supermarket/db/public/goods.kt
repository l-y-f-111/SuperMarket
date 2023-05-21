package supermarket.db.public

import org.ktorm.schema.Table
import org.ktorm.schema.*

object GoodsTable : Table<Nothing>("goods") {
    val goods_id = long("goods_id")
    val goods_name = text("goods_name")
    val goods_is_ready = boolean("goods_is_ready")
    val goods_types = text("goods_types")
    val goods_price = double("goods_price")
    val goods_cover_img = text("goods_cover_img")
    val goods_preview_video_url = text("goods_preview_video_url")
    val goods_stock = long("goods_stock")
}
