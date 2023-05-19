import {createApp} from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import {loadFonts} from './plugins/webfontloader'
import router from '@/plugins/router'
import '@/styles/v_snackbar.styl'

loadFonts().then()

createApp(App)
    .use(router)
    .use(vuetify)
    .mount('#app')
