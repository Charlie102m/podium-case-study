<template>
  <nav>
    <img
      src="https://podium-solutions.co.uk/wp-content/uploads/2020/02/Podium-logo@2x.png"
    />
    <p v-if="showLogout" @click="logout">Logout</p>
  </nav>
</template>

<script lang="ts">
import { useRoute, useRouter } from "vue-router";
import { computed, defineComponent } from "vue";
import { useStore } from "vuex";
import { Routes, Actions } from "@/types";

export default defineComponent({
  setup() {
    const route = useRoute();
    const store = useStore();
    const router = useRouter();

    const showLogout = computed(() => route.name !== Routes.Register);

    const logout = () => {
      store.dispatch(Actions.Logout);
      router.push({ name: Routes.Register });
    };

    return { showLogout, logout };
  },
});
</script>

<style scoped>
nav {
  padding: 30px;
  background-color: var(--primary);
  display: flex;
  justify-content: space-between;
}

nav p {
  font-weight: bold;
  color: var(--off-white);
  text-decoration: none;
  margin: 0;
}

nav p:hover {
  color: var(--secondary);
  cursor: pointer;
}
</style>
