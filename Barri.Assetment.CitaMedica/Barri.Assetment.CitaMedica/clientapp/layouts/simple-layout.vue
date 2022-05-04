<template>
  <div class="simple_layout">
    <header-component />
    <div class="h-screen container pt-16 mx-auto shadow-lg bg-white">
      <slot />
    </div>
  </div>
</template>
<script>
export default {
  layout: 'simple-layout'
}
</script>
