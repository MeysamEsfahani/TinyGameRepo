import { Component, Inject } from '@angular/core';

import { interval } from 'rxjs';

import { DndDropEvent } from 'ngx-drag-drop';

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

  draggable = {
    // note that data is handled with JSON.stringify/JSON.parse
    // only set simple data or POJO's as methods will be lost
    data: "myDragData",
    effectAllowed: "all",
    disable: false,
    handle: false
  };

  onDragStart(event:DragEvent) {

    console.log("drag started", JSON.stringify(event, null, 2));
  }

  onDragEnd(event:DragEvent) {

    console.log("drag ended", JSON.stringify(event, null, 2));
  }

  onDraggableCopied(event:DragEvent) {

    console.log("draggable copied", JSON.stringify(event, null, 2));
  }

  onDraggableLinked(event:DragEvent) {

    console.log("draggable linked", JSON.stringify(event, null, 2));
  }

  onDraggableMoved(event:DragEvent) {

    console.log("draggable moved", JSON.stringify(event, null, 2));
  }

  onDragCanceled(event:DragEvent) {

    console.log("drag cancelled", JSON.stringify(event, null, 2));
  }

  onDragover(event:DragEvent) {

    console.log("dragover", JSON.stringify(event, null, 2));
  }

  onDrop(event:DndDropEvent) {

    console.log("dropped", JSON.stringify(event, null, 2));
  }
}

