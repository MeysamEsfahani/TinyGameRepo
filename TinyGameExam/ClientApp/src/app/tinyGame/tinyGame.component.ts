import { Component, Inject } from '@angular/core';

import { interval } from 'rxjs';

interface NationalityCards {
  name: string;
}

interface Question {
  ID: Number;
  Url : String ;
}


@Component({
  selector: 'app-tinyGame.component',
  templateUrl: './tinyGame.component.html',
  styleUrls: ['./tinyGame.component.css'],
  
})
export class TinyGameComponent {

  
  
  cards: NationalityCards[] = [
    {name: "Chinese"},
    {name: "Japanese"},
    {name: "Korean"},
    {name: "Thai"},
  ];

  secound :number = 0;
  pic_offset : number  =0;
  screenHeight = window.innerHeight;
  picHeight = document.querySelector('question');


  sub = interval(3000/this.pic_offset)
    .subscribe((val) => { 
    //  if(this.pic_offset >= this.screenHeight-100)
    //  this.pic_offset=0;
    //  this.secound += 1 ;
    //  this.pic_offset +=  1 ; 
    //  console.log(this.picHeight);
      
     //console.log(this.pic_offset);
  });
}

