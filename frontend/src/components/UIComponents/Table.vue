<template>
  <table class="table">
    <thead>
      <slot name="columns">
        <th v-for="label in labels">{{label}}</th>
        <th>Options</th>
      </slot>
    </thead>
    <tbody>
    <tr v-for="item in data">
      <slot :row="item">
        <td v-for="column in columns" v-if="hasValue(item, column)">{{itemValue(item, column)}}</td>
        <td>
          <router-link class="btn btn-light btn-fill" v-if="routeName === 'EditFiche'" :to="{name: routeName, params: { id: item.Id }}" style="margin:3px"><i class="fa fa-edit" aria-hidden="true"></i></router-link>
          <button class="btn btn-danger btn-fill" style="margin:3px" @click="$emit('delete', item.Id)"><i class="fa fa-trash" aria-hidden="true"></i></button>
        </td>
      </slot>
    </tr>
    </tbody>
  </table>
</template>
<script>
  export default {
    name: 'l-table',
    props: {
      routeName: String,
      columns: Array,
      labels: Array,
      data: Array
    },
    methods: {
      hasValue (item, column) {
        return item[column] !== 'undefined'
      },
      itemValue (item, column) {
        if (item[column]==null) return "";

        if(column=="Date_cre" || column=="Date_nais" || column=="Date")
          return item[column].substr(0, 10);
        if(column=="Patient")
          return item[column]["Nom_fiche"];

        return item[column];
      }
    }
  }
</script>
<style>
</style>
