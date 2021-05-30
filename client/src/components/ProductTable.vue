<template>
  <table>
    <thead>
      <tr>
        <th>Lender</th>
        <th>Interest Rate</th>
        <th>Interest Type</th>
        <th>Loan-to-value</th>
      </tr>
    </thead>
    <tbody>
      <p v-if="!rows.length" class="empty-state">No results</p>
      <tr v-else v-for="row in rows" :key="row.lender">
        <td>{{ row.lender }}</td>
        <td>{{ `${row.interestRate * 100}%` }}</td>
        <td>{{ row.interestTypeName }}</td>
        <td>{{ `&#60; ${row.loanToValue * 100}%` }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script lang="ts">
import { Product, InterestType } from "@/types";
import { defineComponent, PropType, computed } from "vue";

export default defineComponent({
  name: "ProductTable",
  props: {
    products: { type: Array as PropType<Product[]>, required: true },
  },
  setup(props) {
    const rows = computed(() =>
      props.products.map((product) => ({
        ...product,
        interestTypeName: InterestType[product.interestType],
      }))
    );

    return { rows };
  },
});
</script>

<style scoped>
table {
  border-collapse: collapse;
  margin: 25px 0;
  font-size: 0.9em;
  width: 100%;
  box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
}

table thead tr {
  background-color: var(--primary);
  color: var(--white);
  text-align: left;
}

table th,
table td {
  padding: 12px 15px;
}

table tbody tr:nth-of-type(even) {
  background-color: var(--off-white);
}

table tbody tr:last-of-type {
  border-bottom: 2px solid var(--primary);
}

.empty-state {
  padding-left: 10px;
}
</style>
