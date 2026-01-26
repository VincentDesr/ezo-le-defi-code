<template>
  <v-container>
    <v-row justify="center">
      <v-col cols="12" md="8" lg="6">
        <v-card elevation="3" class="pa-4">
          <v-card-title class="text-h4 text-center mb-4">
            String Calculator
          </v-card-title>

          <v-card-text>
            <!-- Expression Input -->
            <v-text-field
              v-model="expression"
              label="Enter mathematical expression"
              placeholder="e.g., 2+2*5+5 or sqrt(16)+4"
              variant="outlined"
              clearable
              :disabled="loading"
              :error-messages="errorMessage"
              @keyup.enter="calculate"
              @input="clearError"
            >
              <template v-slot:append>
                <v-icon>mdi-calculator</v-icon>
              </template>
            </v-text-field>

            <!-- Result Display -->
            <v-card
              v-if="result !== null"
              color="primary"
              variant="tonal"
              class="pa-4 mb-4"
            >
              <div class="text-h6">Result:</div>
              <div class="text-h3 font-weight-bold">{{ result }}</div>
            </v-card>

            <!-- Calculate Button -->
            <v-btn
              block
              color="primary"
              size="large"
              :loading="loading"
              :disabled="!expression || loading"
              @click="calculate"
            >
              <v-icon start>mdi-equal</v-icon>
              Calculate
            </v-btn>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { CalculatorApiError, CalculatorServiceFactory } from '../services/calculatorService';

// Service instance
const calculatorService = CalculatorServiceFactory.createService();

// Reactive state
const expression = ref<string>('');
const result = ref<number | null>(null);
const loading = ref<boolean>(false);
const errorMessage = ref<string>('');

/**
 * Clears any error messages and result
 */
const clearError = (): void => {
  errorMessage.value = '';
  result.value = null;
};

/**
 * Calculates the expression result
 */
const calculate = async (): Promise<void> => {
  if (!expression.value) {
    return;
  }

  loading.value = true;
  clearError();
  result.value = null;

  try {
    const calculatedResult = await calculatorService.evaluate(expression.value);
    result.value = calculatedResult;
  } catch (error) {
    if (error instanceof CalculatorApiError) {
      errorMessage.value = error.detail;
    } else {
      errorMessage.value = 'An unexpected error occurred. Please try again.';
    }
    console.error('Calculator error:', error);
  } finally {
    loading.value = false;
  }
};
</script>

<style scoped>
.cursor-pointer {
  cursor: pointer;
}

.cursor-pointer:hover {
  background-color: rgba(0, 0, 0, 0.04);
}
</style>
