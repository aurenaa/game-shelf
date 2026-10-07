import { Component } from '@angular/core';
import { GameService } from '../../services/game.service';
import { RawgGame } from '../../models/rawg-game.model';

@Component({
  selector: 'app-trending-games',
  templateUrl: './trending-games.component.html',
  styleUrls: ['./trending-games.component.css']
})
export class TrendingGamesComponent {
  games: RawgGame[] = [];
  loading = true;

  constructor(private gameService: GameService) {}

  ngOnInit() {
    this.gameService.getTrending().subscribe({
      next: (games) => {
        this.games = games;
        this.loading = false;
      },
      error: (err) => {
        console.error("Error:", err);
        this.loading = false;
      }
    })
  }
}
