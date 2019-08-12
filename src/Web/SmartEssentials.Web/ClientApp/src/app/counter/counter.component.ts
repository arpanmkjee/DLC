import { Component, OnInit, AfterViewInit } from '@angular/core';
declare var jquery: any;
declare var $: any;

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent implements OnInit, AfterViewInit {
  public currentCount = 0;

  ngAfterViewInit() {
    //var instance = $('.panel-danger').data('lobiPanel');
    //instance.unpin();
    //instance.setPosition(500, 50);
  }
  save() {
    alert(JSON.stringify($('.panel-success').lobiPanel("getPosition")));
  }


  ngOnInit() {
    
    $(function () {
      $('.panel').lobiPanel({
        //minimize: {
        //  icon: 'glyphicon glyphicon-chevron-up',
        //  icon2: 'glyphicon glyphicon-chevron-down'
        //},
        reload: false,
        close: false,
        editTitle: false,
        unpin: false,
        sortable: true,
        bodyHeight: 500,
        maxWidth: 1200,
        maxHeight: 2000,
        minWidth: 100,
        draggable: true,
        resize: "both",
        //expand: true,
      });

      //$('.panel-success').on('dragged.lobiPanel', function (ev, lobiPanel) {
      //  alert("dragged");
      //});





    });

    this.setPanels('.panel-danger', 500, 50);
    this.setPanels('.panel-success', 950, 50);
    this.setPanels('.panel-warning', 1400, 50);
    this.setPanels('.panel-info', 500, 630);

  }

  public setPanels(className: string, left: number, top: number) {
    $(function () {
      var instance = $(className).data('lobiPanel');
      instance.unpin();
      instance.setPosition(left, top);
      instance.setWidth(400);

      if (className == '.panel-danger') {
        instance.startLoading();
      }

    });

  }

  //#btn
  public incrementCounter() {
    this.currentCount++;
  }
}
