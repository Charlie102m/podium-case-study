<template>
  <h1>Register User</h1>
  <hr />
  <form @submit.prevent="handleSubmit">
    <TextField
      v-model="firstName"
      name="firstName"
      id="firstName"
      placeholder="Enter your first name..."
      label="First Name"
      required
    />
    <TextField
      v-model="lastName"
      name="lastName"
      id="lastName"
      placeholder="Enter your last name..."
      label="Last Name"
      required
    />
    <TextField
      type="date"
      v-model="dateOfBirth"
      name="dateOfBirth"
      id="dateOfBirth"
      placeholder="Enter your date of birth..."
      label="Date of Birth"
      required
    />
    <TextField
      type="email"
      v-model="email"
      name="email"
      id="email"
      placeholder="Enter your email..."
      label="Email"
      required
    />
    <Button type="submit">Register</Button>
  </form>
</template>

<script lang="ts">
import { defineComponent, reactive, toRefs } from "vue";
import { TextField, Button } from "@/components";
import { useRouter } from "vue-router";
import { useStore } from "vuex";
import { Routes, Actions } from "@/types";

export default defineComponent({
  name: "RegisterUser",
  components: {
    TextField,
    Button,
  },
  setup() {
    const state = reactive({
      firstName: "",
      lastName: "",
      dateOfBirth: "",
      email: "",
    });
    const router = useRouter();
    const store = useStore();

    const handleSubmit = async () => {
      const response = await fetch("https://localhost:5001/Auth/register", {
        method: "POST",
        cache: "no-cache",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(state),
      });

      if (response.ok) {
        const data = await response.json();
        store.dispatch(Actions.Authenticate, data.userId);
        router.push({ name: Routes.Search });
      }
    };

    return { ...toRefs(state), handleSubmit };
  },
});
</script>
