<template>
    <div>

        <div style="display:flex;margin-top:50px">
            <v-card class="mx-auto">

                <v-card-title>
                    <h4>
                        <v-chip
                                color="orange"
                                size="x-large"
                                variant="text"
                        >
                            你好！用户{{ user_id }}
                        </v-chip>
                    </h4>
                </v-card-title>
                <v-card-text>
                    <div>
                        <v-chip
                                size="large"
                                variant="text"
                        >
                            会员等级
                        </v-chip>
                        <v-chip
                                color="orange"
                                class="mx-2"
                        >
                            LEVEL {{ UserVipLevel }}
                        </v-chip>
                        <v-chip
                                color="green"
                                class="mx-2"
                        >
                            享受{{ UserVipDiscount * 10 }}折优惠
                        </v-chip>
                    </div>
                    <div>
                        <v-chip
                                color="gray"
                                size="large"
                                variant="text"
                        >
                            绑定手机
                        </v-chip>
                        <v-chip
                                color="orange"
                                class="mx-2"
                        >
                            {{ user_id }}
                        </v-chip>
                    </div>
                </v-card-text>
                <v-card-actions>
                    <v-btn
                            prepend-icon="mdi-cellphone"
                            color="orange"
                            @click=""
                    >
                        改绑手机
                    </v-btn>
                    <v-btn
                            prepend-icon="mdi-lock-reset"
                            color="orange"
                            @click="router.push('/reset_pwd/'+user_id)"
                    >
                        修改密码
                    </v-btn>
                    <!--
                              <v-btn
                                  prepend-icon="mdi-crown"
                                  color="orange"
                                  @click="router.push('/upgrade_vip/'+user_id)"
                              >
                                升级会员
                              </v-btn>-->
                </v-card-actions>


            </v-card>
        </div>

    </div>
</template>

<script lang="ts" setup>

import {useRouter} from "vue-router"
import {onMounted, ref} from "vue"
import {getUser} from "@/scripts/ws/user/getUser"
import {UserVipDiscount, UserVipLevel} from "@/scripts/state/user"

const router = useRouter()

const props =
    defineProps<{
        user_id: bigint,
    }>()

const _UserVipLevel = ref(-1n)
const _UserVipLevelDiscount = ref(-1.0)

onMounted(async () => {
    const user = await getUser({UserId: props.user_id})
    if (user.Ok) {
        UserVipLevel.value = user.UserVipLevel
        UserVipDiscount.value = user.UserVipLevelDiscount
        _UserVipLevel.value = user.UserVipLevel
        _UserVipLevelDiscount.value = user.UserVipLevelDiscount
    }
})

</script>

<style lang="stylus" scoped>


</style>