import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Game } from '../models/game.model';
import { RawgGame } from '../models/rawg-game.model';

@Injectable({ providedIn: 'root' })
export class GameService {
    private apiUrl = `${environment.apiUrl}/Games`;

    constructor(private http: HttpClient) {}

    getAll(): Observable<Game[]> {
        return this.http.get<Game[]>(this.apiUrl);
    }

    getById(id: number): Observable<Game> {
        return this.http.get<Game>(`${this.apiUrl}/${id}`);
    }

    getTrending(): Observable<RawgGame[]> {
    return this.http.get<RawgGame[]>(`${this.apiUrl}/trending`);
    }
}