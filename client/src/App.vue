<template>
  <AppBar />
  <div class="container">
    <router-view />
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { AppBar } from "@/components";

export default defineComponent({
  components: {
    AppBar,
  },
});
</script>

<style>
:root {
  --primary: #130573;
  --secondary: #90b8f7;
  --off-white: #eee;
  --white: #fff;
}

body {
  margin: 0;
  padding: 0;
}

hr {
  border: 0;
  height: 2px;
  background-image: linear-gradient(
    to right,
    var(--secondary),
    var(--primary),
    var(--secondary)
  );
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  color: var(--primary);
}

.container {
  max-width: 800px;
  width: 100%;
  margin: 100px auto 0;
}
</style>
