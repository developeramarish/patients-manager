<template>
  <div class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-xl-4 col-md-6">
          <stats-card v-if="nbr_patient">
            <div slot="header" class="icon-warning">
              <i class="nc-icon nc-single-02 text-warning"></i>
            </div>
            <div slot="content">
              <p class="card-category">Patients</p>
              <h4 class="card-title">{{nbr_patient}}</h4>
            </div>
            <div slot="footer">
              <i class="fa fa-refresh"></i>Updated now
            </div>
          </stats-card>
        </div>

        <div class="col-xl-4 col-md-6">
          <stats-card v-if="nbr_rendezvous">
            <div slot="header" class="icon-success">
              <i class="nc-icon nc-watch-time text-success"></i>
            </div>
            <div slot="content">
              <p class="card-category">Rendez-vous</p>
              <h4 class="card-title">{{nbr_rendezvous}}</h4>
            </div>
            <div slot="footer">
              <i class="fa fa-refresh"></i>Updated now
            </div>
          </stats-card>
        </div>

        <div class="col-xl-4 col-md-6">
          <stats-card v-if="nbr_comptab">
            <div slot="header" class="icon-info">
              <i class="nc-icon nc-money-coins text-info"></i>
            </div>
            <div slot="content">
              <p class="card-category">Flux</p>
              <h4 class="card-title">{{nbr_comptab}}</h4>
            </div>
            <div slot="footer">
              <i class="fa fa-refresh"></i>Updated now
            </div>
          </stats-card>
        </div>



      </div>
      <div class="row">
        <div class="col-md-8">
          <chart-card v-if="lineChartLoaded" :chart-data="lineChart.data"
                      :chart-options="lineChart.options"
                      :responsive-options="lineChart.responsiveOptions">
            <template slot="header">
              <h4 class="card-title">Flux Comportement</h4>
              <p class="card-category">Pérformance du mois</p>
            </template>
            <template slot="footer">
              <div class="legend">
                <i class="fa fa-circle text-info"></i> Recettes
                <i class="fa fa-circle text-danger"></i> Dépenses
              </div>
              <hr>
              <div class="stats">
                <i class="fa fa-refresh"></i>Updated now
              </div>
            </template>
          </chart-card>
        </div>

        <div class="col-md-4">
          <chart-card v-if="pieChartLoaded" :chart-data="pieChart.data" chart-type="Pie">
            <template slot="header">
              <h4 class="card-title">Flux Statistiques</h4>
              <p class="card-category">Dépenses & Recettes</p>
            </template>
            <template slot="footer">
              <div class="legend">
                <i class="fa fa-circle text-info"></i> Recettes
                <i class="fa fa-circle text-danger"></i> Dépenses
              </div>
              <hr>
              <div class="stats">
                <i class="fa fa-refresh"></i>Updated now
              </div>
            </template>
          </chart-card>
        </div>
      </div>


    </div>
  </div>
</template>
<script>
  import ChartCard from 'src/components/UIComponents/Cards/ChartCard.vue'
  import StatsCard from 'src/components/UIComponents/Cards/StatsCard.vue'
  import Card from 'src/components/UIComponents/Cards/Card.vue'
  import LTable from 'src/components/UIComponents/Table.vue'
  import Checkbox from 'src/components/UIComponents/Inputs/Checkbox.vue'

  export default {
    components: {
      Checkbox,
      Card,
      LTable,
      ChartCard,
      StatsCard
    },
    methods: {
      renderChart()
      {
          this.$http.get(`http://localhost:2573/api/comtab/`)
          .then(response => {
            this.flux = response.data
            this.flux.forEach(element => {
              if(element["Type"]=="depense")
              {
                this.depenses += element["Montant"];
                this.lineChart.data.series[1].push(element["Montant"]);
                this.lineChart.data.labels.push(element["Date"].substr(5, 5));
              }
              if(element["Type"]=="recette")
              {
                this.recettes += element["Montant"];
                this.lineChart.data.series[0].push(element["Montant"]);
                //this.lineChart.data.labels.push(element["Date"].substr(5, 5));
              }
            });
            var sum = this.depenses + this.recettes;
            this.pieChart.data.series[1] = this.depenses;
            this.pieChart.data.labels[1] = parseInt((this.depenses/sum)*100)+"%";
            this.pieChart.data.series[0] = this.recettes;
            this.pieChart.data.labels[0] = parseInt((this.recettes/sum)*100)+"%";
            this.pieChartLoaded = true;
            this.lineChartLoaded = true;
          });
      }
    },
    created(){
      this.renderChart();
    },
    mounted() {
      this.$http.get(`http://localhost:2573/api/patient/count`)
        .then(response => {
          this.nbr_patient = response.data
        });
      this.$http.get(`http://localhost:2573/api/rendezvous/count`)
        .then(response => {
          this.nbr_rendezvous = response.data
        });
      this.$http.get(`http://localhost:2573/api/comtab/count`)
        .then(response => {
          this.nbr_comptab = response.data
        });
    },
    data () {
      return {
        editTooltip: 'Edit Task',
        deleteTooltip: 'Remove',
        nbr_patient:0,
        nbr_comptab:0,
        nbr_rendezvous:0,
        depenses:0,
        recettes:0,
        flux:[],
        pieChartLoaded: false,
        pieChart: {
          data: {
            labels: [],
            series: []
          }
        },
        lineChartLoaded: false,
        lineChart: {
          data: {
            labels: [],
            series: [
              [],
              []
            ]
          },
          options: {
            low: 0,
            high: 800,
            showArea: false,
            height: '245px',
            axisX: {
              showGrid: false
            },
            lineSmooth: true,
            showLine: true,
            showPoint: true,
            fullWidth: true,
            chartPadding: {
              right: 50
            }
          },
          responsiveOptions: [
            ['screen and (max-width: 640px)', {
              axisX: {
                labelInterpolationFnc (value) {
                  return value[0]
                }
              }
            }]
          ]
        }
      }
    }
  }
</script>
<style>

</style>
