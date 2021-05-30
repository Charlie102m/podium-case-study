<template>
  <div class="wrapper">
    <label :for="id">
      {{ label }}
    </label>
    <input
      class="input"
      :type="type"
      v-model="message"
      :placeholder="placeholder"
      :id="id"
      :name="name"
      :required="required"
    />
  </div>
</template>

<script lang="ts">
import { computed, defineComponent } from "vue";

export default defineComponent({
  name: "TextField",
  props: {
    modelValue: [String, Number],
    label: String,
    name: String,
    id: String,
    placeholder: String,
    type: String,
    required: Boolean,
  },
  setup(props, { emit }) {
    const message = computed({
      get: () => props.modelValue,
      set: (value) => emit("update:modelValue", value),
    });

    return { message };
  },
});
</script>

<style scoped>
label {
  display: block;
  margin: 15px;
  color: var(--primary);
  font-size: 1.5rem;
}

input {
  box-sizing: border-box;
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  font-size: 1.5rem;
  padding: 0.3em 0.5em;
  background-color: var(--white);
  border: 2px solid var(--off-white);
  border-radius: 4px;
  width: 100%;
}

input:focus {
  border: 2px solid var(--white) !important;
  outline: none;
  box-shadow: 0 0 0 3px var(--secondary);
}

.wrapper {
  margin: 50px 5px;
}
</style>
