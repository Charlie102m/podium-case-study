<template>
  <h1>Product Search</h1>
  <hr />
  <form @submit.prevent="handleSubmit">
    <TextField
      type="number"
      v-model="propertyValue"
      name="propertyValue"
      id="propertyValue"
      placeholder="Enter the property value..."
      label="Property Value"
    />
    <TextField
      type="number"
      v-model="deposit"
      name="deposit"
      id="deposit"
      placeholder="Enter the deposit..."
      label="Deposit"
    />
    <Button type="submit">Search</Button>
  </form>
  <p v-if="error" class="error">{{ error }}</p>
  <p v-if="isInitialLoad">Use the fields above to search for mortgages.</p>
  <ProductTable v-else :products="products" />
</template>

<script lang="ts">
import { defineComponent, reactive, ref, toRefs } from "vue";
import { TextField, ProductTable, Button } from "@/components";
import { useStore } from "vuex";
import { Product } from "@/types";

export default defineComponent({
  name: "Search",
  components: {
    TextField,
    ProductTable,
    Button,
  },
  setup() {
    const store = useStore();
    const state = reactive({
      propertyValue: 0,
      deposit: 0,
    });
    const error = ref("");
    const products = ref<Product[]>([]);
    const isInitialLoad = ref(true);

    const handleSubmit = async () => {
      isInitialLoad.value = false;
      products.value = [];

      const response = await fetch(
        `https://localhost:5001/Product/search?PropertyValue=${state.propertyValue}&Deposit=${state.deposit}&UserId=${store.state.token}`
      );

      const data = await response.json();

      if (response.ok) {
        products.value = data;
      } else {
        error.value = data.detail;
      }
    };

    return { ...toRefs(state), handleSubmit, error, products, isInitialLoad };
  },
});
</script>

<style scoped>
.error {
  color: red;
}
</style>
