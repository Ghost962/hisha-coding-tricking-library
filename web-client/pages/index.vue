<template>
  <div>
    <div v-if="tricks">
      <div v-for="t in tricks">
        {{ t.name }}
        <div>
          <video :src="`http://localhost:5000/api/videos/${t.video}`" controls width="400"></video>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
import {mapState} from 'vuex';

export default {
  computed: mapState('tricks', ['tricks']),

}
</script>
