import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-movie-list',
  templateUrl: 'movie-list.component.html',
  styleUrls: ['movie-list.component.css']
})
export class MovieListComponent implements OnInit {

  movies: Array<any> = [
    {
      "Id": 1,
      "Name": "Tetris",
      "Genre": "Drama, History",
      "Actors": "Taron Egerton, Nikita Efremov, Sofia Lebedeva",
    },
    {
      "Id": 2,
      "Name": "Creed III (2023)",
      "Genre": "Drama, Action",
      "Actors": "Michael B. Jordan ,Tessa Thompson, Jonathan Majors",
    },
    {
      "Id": 3,
      "Name": "Dungeons & Dragons",
      "Genre": "Action, Fantasy",
      "Actors": "Taron Egerton, Nikita Efremov, Sofia Lebedeva",

    },
    {
      "Id": 4,
      "Name": "Tetris",
      "Genre": "Drama, History",
      "Actors": "Taron Egerton, Nikita Efremov, Sofia Lebedeva",

    },
    {
      "Id": 5,
      "Name": "Tetris",
      "Genre": "Drama, History",
      "Actors": "Taron Egerton, Nikita Efremov, Sofia Lebedeva",

    },
    {
      "Id": 6,
      "Name": "Tetris",
      "Genre": "Drama, History",
      "Actors": "Taron Egerton, Nikita Efremov, Sofia Lebedeva",

    },
  ]
  constructor() { }
  ngOnInit(): void {

  }
}

