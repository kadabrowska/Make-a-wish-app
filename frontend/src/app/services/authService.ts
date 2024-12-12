import { Injectable } from "@angular/core";
import { jwtDecode } from "jwt-decode";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private tokenKey = 'authToken';
    private currentUserId: number | null = null;

    setToken(token: string): void {
        localStorage.setItem(this.tokenKey, token);
        this.setUserIdFromToken(token);
    }

    getToken(): string | null {
        return localStorage.getItem(this.tokenKey);
    }

    setUserId(userId: number) : void {
        this.currentUserId = userId;
    }

    getCurrentUserId(): number | null {
        return this.currentUserId;
    }

    private setUserIdFromToken(token: string): void {
        const decodedToken: any = jwtDecode(token);
        if (decodedToken && decodedToken.userId) {
            this.currentUserId = +decodedToken.userId;
            console.log("decoded user id:", this.currentUserId);
        } else {
            console.error("userId not found in token");
        }
        }

        loadUserIdFromToken(): void {
            const token = this.getToken();
            if(token)
                this.setUserIdFromToken(token);
        }
    };