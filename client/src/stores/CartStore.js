import {defineStore} from "pinia";
import {computed, ref} from "vue";
import {useUserStore} from "@/stores/UserStore.js";


export const useCartStore = defineStore('cart', () => {

    const userStore = useUserStore();

    const cartIsShowed = ref(false);
    const userCart = ref({
        content: []
    });


    const purchasesSum = computed(() => {
        let sum = 0;

        userCart.value.content?.forEach(item => sum += item.price);
        return sum;
    })


    // Cart display
    function showCart() {
        cartIsShowed.value = true;
    }

    function hideCart() {
        cartIsShowed.value = false;
    }

    function toggleCartDisplay() {
        cartIsShowed.value === true ? hideCart() : showCart()
    }

    // Cart actions
    function addToCart(card) {
        userCart.value.content.push(card);
    }

    function removeFromCart(purchase) {
        let itemIndex = getPurchaseIndex();

        userCart.value.content.splice(itemIndex, 1)

        function getPurchaseIndex() {
            return userCart.value.content.findIndex(p => p.id === purchase.id);
        }
    }

    function clearCart() {
        userCart.value.content.length = 0;
    }


    return {
        isCartShowed: cartIsShowed,
        showCart,
        hideCart,
        purchasesSum,
        userCart,
        toggleCartDisplay,
        addToCart,
        removeFromCart,
        clearCart,
    };
})