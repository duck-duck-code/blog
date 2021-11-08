import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Article } from '../model/article.entity';
import { Repository } from 'typeorm';
import { CreateArticleDto, ArticleDto } from './dto';

@Injectable()
export class ArticleService {
  constructor(
    @InjectRepository(Article) private readonly repo: Repository<Article>,
  ) {}

  public async getAllArticles(): Promise<ArticleDto[]> {
    return await this.repo.find();
  }

  public async createArticle(dto: CreateArticleDto): Promise<Article> {
    return this.repo.save({
      ...dto,
      createDateTime: new Date(),
      lastChangedDateTime: new Date(),
      createdBy: 'no-one',
      lastChangedBy: 'no-one',
    });
  }
}
