<script setup>

import {ref} from "vue";


const darkMode = ref(false);

function toggleDarkMode() {
  darkMode.value = !darkMode.value;
}

</script>

<template>
  <div class="circle day_light"
       :class="{
        night_light: darkMode,
      }"
       @click="toggleDarkMode"
  >

    <div class="sun sunTop"
         :class="{
        sunBottom: darkMode,
      }"/>

    <div class="moon moonBottom"
         :class="{
        moonTop: darkMode,
      }"

    />


    <div class="cat day_cat"
         :class="{
        night_cat: darkMode,
      }">

      <div class="ears">

      </div>
      <div class="face">

        <div class="noise"/>

        <div class="eyes">
          <div class="left_eye">
            <div class="pupil  day_pupil"
                 :class="{
        night_pupil: darkMode,
      }"/>
          </div>
          <div class="right_eye">
            <div class="pupil day_pupil"
                 :class="{
        night_pupil: darkMode,
      }"/>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>

<style scoped>

.circle {
  position: relative;
  display: flex;
  overflow: hidden;
  margin: auto;

  //width: 20vw;
  //min-width: 160px;
  width: 105px;
  //max-width: 300px;
  aspect-ratio: 1/1;
  border-radius: 50%;
  cursor: pointer;

  transition: all 1000ms ease;
}

.sun {
  position: absolute;

  top: 10%;
  right: 30%;

  aspect-ratio: 1/1;
  width: 15%;
  max-width: 50px;

  border-radius: 50%;
  background-color: yellow;
  transition: all 1000ms ease;
}

.moon {
  position: absolute;

  top: 10%;
  left: 30%;

  aspect-ratio: 1/1;
  width: 15%;
  max-width: 30px;

  border-radius: 50%;
  background-color: rgba(89, 89, 89, 0.36);
  transition: all 1000ms ease;
}

.cat {
  position: relative;
  width: 50%;
  height: 60%;

  margin: auto;
  margin-top: 55%;;

  background-color: #9d9d9d;
  transition: all 1000ms ease;
}

.face {
  position: relative;
  width: 100%;
  height: 100%;

  display: flex;
  flex-direction: row;
}


.ears {
  position: absolute;

  width: 100%;
  height: 30px;
}

.ears:before {
  display: block;
  width: 0;
  height: 0;
  border-left: 0 solid transparent;
  border-right: 2rem solid transparent;
  border-bottom: 20px solid #777;
  left: 0;
  top: -65%;
  position: absolute;
  content: "";
  transform-origin: bottom;
}

.ears:after {
  display: block;
  width: 0;
  height: 0;
  border-right: 0 solid transparent;
  border-left: 2rem solid transparent;
  border-bottom: 20px solid #777;
  top: -65%;
  right: 0;
  position: absolute;
  content: "";
}


.eyes {
  position: absolute;

  top: 15%;
  height: 25%;
  left: 0;
  right: 0;
}

.left_eye {
  position: absolute;
  display: flex;
  justify-content: center;
  align-items: center;

  left: 7px;
  width: 30%;
  height: 100%;


  border-radius: 50%;

  background-color: #ffde54;
}

.right_eye {
  position: absolute;
  display: flex;
  justify-content: center;
  align-items: center;

  right: 7px;
  width: 30%;
  height: 100%;

  border-radius: 50%;

  background-color: #ffde54;

}

.noise {
  position: absolute;
  width: 7%;
  aspect-ratio: 1/1;

  margin-left: auto;
  margin-right: auto;

  left: 0;
  right: 0;

  top: 40%;
  border-radius: 50%;

  background-color: #f3b1cf;
}


.pupil {
  position: absolute;

  width: 45px;
  height: 100%;

  justify-items: center;;

  border-radius: 50%;

  background-color: #5a96c4;

  transition: all 1000ms ease;
}

.sunTop {
  transform: translateY(0);
  opacity: 1;
}

.sunBottom {
  transform: translateY(150px);
  opacity: 0;
}

.moonBottom {
  transform: translateY(150px);
}

.moonTop {
  opacity: 1;
  transform: translateY(0);
}

.day_light {
  background-color: #9bceee;
}

.night_light {
  background-color: #3d3d46;
}

.day_cat {
  background-color: #3d3d46;
}

.night_cat {
  background-color: #53535d;
}

.day_pupil {
  width: 25%;
}

.night_pupil {
  width: 50%;
}


</style>

