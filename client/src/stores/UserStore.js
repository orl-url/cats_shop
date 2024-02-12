import {defineStore} from "pinia";
import {ref} from "vue";


export const useUserStore = defineStore('User', () => {

    const user = ref({
        id: "",
        name: "",
        balance: ""
    })

    function setBalanceValue(value) {
        user.value.balance = value;
    }

    function setUserParams(userParams) {
        user.value.id = userParams.userId;
        user.value.name = userParams.name;
    }

    function clearUserParams() {
        user.value.id = "";
        user.value.name = "";
        user.value.balance = "";
    }

    return {
        user,
        setBalanceValue,
        setUserParams,
        clearUserParams
    };
})