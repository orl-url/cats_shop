export default [
    {
        path: '/',
        name: 'ShopView',
        component: () => import('@/views/ShopView.vue'),
        meta: {
            layout: 'AppLayoutMain',
        },
    },
    {
        path: '/purchases',
        name: 'Purchases',
        component: () => import('@/views/PurchasesView.vue'),
        meta: {
            layout: 'AppLayoutMain',
        },
    },
    {
        path: '/cart',
        name: 'Cart',
        component: () => import('@/views/CartView.vue'),
        meta: {
            layout: 'AppLayoutMain',
        }
    },
    {
        path: '/auth',
        name: 'Auth',
        component: () => import('@/views/AuthView.vue'),
        meta: {
            layout: 'AppLayoutMain',
        },
        children: [
            {
                path: 'signIn',
                name: 'SignIn',
                component: () => import('@/components/auth/SingIn.vue'),
            },
            {
                path: 'signUp',
                name: 'SignUp',
                component: () => import('@/components/auth/SignUp.vue'),
            },
            {
                path: 'signOut',
                name: 'SignOut',
                component: () => import('@/components/auth/SignOut.vue'),
            },
        ],
    }
];

