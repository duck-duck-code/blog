import { Body, Controller, Get, Post } from '@nestjs/common';
import { CreateArticleDto } from './dto/CreateArticle.dto';
import { ArticleService } from './article.service';

@Controller('article')
export class ArticleController {
  constructor(private service: ArticleService) {}

  @Get()
  public async getAll() {
    return await this.service.getAllArticles();
  }

  @Post()
  public async post(@Body() dto: CreateArticleDto) {
    return await this.service.createArticle(dto);
  }
}
