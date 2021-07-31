import { Component, Inject, OnInit } from '@angular/core';

import { interval } from 'rxjs';

import { DndDropEvent } from 'ngx-drag-drop';

import { HttpClient } from '@angular/common/http';
import { filter } from 'rxjs/operators';

interface Country {
  id: number;
  name: string;
}

interface Question {
  id: Number;
  imageUrl: String;
}

interface Score {
  countRightAnswer: number;
  countWrongAnswer: number;
  yourScore: number
}


@Component({
  selector: 'app-tinyGame.component',
  templateUrl: './tinyGame.component.html',
  styleUrls: ['./tinyGame.component.css'],

})
export class TinyGameComponent implements OnInit {

  secound: number = 0;
  picOffset: number = 0;
  screenHeight = window.innerHeight;
  picHeight = document.querySelector('question');
  gameStage: number = 1;
  gameStages: number = 10;

   countries: Country[];
   score: Score;
  question: Question;

  timerState = true;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  ngOnInit(): void {
    this.getCountries();
    this.initializeGame();
    }

  initializeGame() {
    this.getQuestionAPI().subscribe(result => {
      this.question = result;
      this.getScore();
      this.startTimer();
    }, error => console.error(""));;
  }

  startTimer() {
    interval(3000 / this.picOffset).pipe(filter(value => this.timerState))
      .subscribe((val) => {
        if (this.picOffset >= this.screenHeight - 100) {
          this.getFreshQuestion();
        }

        this.secound += 1;
        this.picOffset += 1;
      });
  }

  draggable = {
    data: "myDragData",
    effectAllowed: "all",
    disable: false,
    handle: false
  };

  getScore() {
    this.http.get<Score>(this.baseUrl + 'GetScore').subscribe(result => {
      this.score = result;
    }, error => console.error(""));
  }

  getQuestionAPI() {
    return this.http.get<Question>(this.baseUrl + 'GetQuestion/' + this.gameStage)
  }

  getCountries() {
    this.http.get<Country[]>(this.baseUrl + 'Countries').subscribe(result => {
      this.countries = result;
      this.getScore();
      this.startTimer();
    }, error => console.error(""));
  }

  getFreshQuestion() {
    this.timerState = false;
    this.getScore();
    this.gameStage++;
    if (!this.checkNumberOfStage())
      return;
    this.getQuestionAPI().subscribe(result => {
      this.question = result;
      this.picOffset = 0;
      this.timerState = true;
    });
  }

  checkNumberOfStage(): boolean {
    if (this.gameStage >= this.gameStages) {
      this.timerState = false;
      return false;
    }
    return true;
  }

  onDrop(country: Country, event: DndDropEvent) {
    console.log("nemidonam .....", country);
    this.http.post<any>(this.baseUrl + 'StageResponse', { gameStage: this.gameStage, countryId: country.id }).subscribe(result => {
      console.log(result);
      this.getFreshQuestion();
    }, error => console.error(""));
  }
}

