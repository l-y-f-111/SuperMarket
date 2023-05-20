<template>

    <v-snackbar
            v-model="show_snackbar"
            timeout="-1"
            multi-line
            location="top"
    >
        <v-responsive :aspect-ratio="16/9">
            <iframe
                    class="pv_player"
                    :src="props.pv_url"
            />
        </v-responsive>

        <template v-slot:actions>
            <v-btn
                    variant="text"
                    @click="show_snackbar = false"
            >
                关闭
            </v-btn>
        </template>
    </v-snackbar>

    <v-card
            class="mx-1 mt-2 movie_card"
    >
        <img
                :src="cover_img"
                style="width:100%;object-fit:contain;"
                alt=""
        />
        <v-card-title>
            <span>{{ props.name }}</span>
            <v-chip
                    color="green"
                    variant="text"
                    style="float: right;font-weight: 600"
            >{{ props.price }} 元
            </v-chip>
        </v-card-title>

        <v-card-actions>
            <v-btn
                    variant="text"
                    color="primary"
                    @click="router.push('/'+props.booking_route)"
                    :disabled="!IsUserLogin||props.stock==0"
            >
                购买
            </v-btn>
            <v-btn
                    variant="text"
                    color="blue"
                    @click="show_snackbar=true"
            >
                观看介绍视频
            </v-btn>
        </v-card-actions>

    </v-card>

</template>

<script lang="ts" setup>

import {ref} from "vue"
import {useRouter} from "vue-router"
import {IsUserLogin, IsUserAdmin} from "@/scripts/state/user"

const router = useRouter()
const props = defineProps<{
    name: string,
    cover_img: string,
    booking_route: string,
    price: number,
    pv_url: string
    stock: number
}>()

const show_snackbar = ref(false)

</script>

<style lang="stylus" scoped>

.pv_player
  width 60vw
  height 70vh

.movie_card
  min-width 240px
  width 18%

</style>