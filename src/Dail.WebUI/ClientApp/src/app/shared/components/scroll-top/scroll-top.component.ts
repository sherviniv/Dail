import { Component, OnInit } from '@angular/core';
declare var $: any;

@Component({
  selector: 'dail-scroll-top',
  templateUrl: './scroll-top.component.html',
  styleUrls: ['./scroll-top.component.scss']
})
export class ScrollTopComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    var btn = $('#scrollbutton');
    $(window).on("scroll",function () {
      if ($(window).scrollTop() as any > 300) {
        btn.addClass('show');
      } else {
        btn.removeClass('show');
      }
    });
    btn.on('click', function (e : any) {
      e.preventDefault();
      $('html, body').animate({ scrollTop: 0 }, '300');
    });
  }

}
