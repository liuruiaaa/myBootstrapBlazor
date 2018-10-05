package com.imooc.cake.mapper;

import com.imooc.cake.entity.Cake;
import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.Param;
import org.apache.ibatis.annotations.Result;
import org.apache.ibatis.annotations.Results;
import org.apache.ibatis.annotations.Select;

import java.util.List;

/**
 *
 * 蛋糕
 *
 * @version 1.0
 */
public interface CakeMapper {

    /**
     * 分页查询蛋糕
     * @param skip  跳过的记录数，也就是从哪条开始查询
     * @param size  要查询的记录数
     * @return  蛋糕集合
     */
    @Select("select * from cake order by create_time desc limit #{skip}, #{size}")
    @Results({
                @Result(id = true, column = "id", property = "id"),
                @Result(column = "category_id", property = "categoryId"),
                @Result(column = "name", property = "name"),
                @Result(column = "level", property = "level"),
                @Result(column = "price", property = "price"),
                @Result(column = "create_time", property = "createTime"),
                @Result(column = "update_time", property = "updateTime")
            })
    List<Cake> getCakes(@Param("skip") Integer skip, @Param("size") Integer size);

    /**
     * 根据分类分页查询蛋糕
     * @param categoryId    蛋糕分类ID
     * @param skip  跳过的记录数，也就是从哪条开始查询
     * @param size  要查询的记录数
     * @return  蛋糕集合
     */
    @Select("select id, category_id categoryId, name, level, price, create_time createTime, update_time updateTime " +
            "from cake where category_id = #{categoryId} order by create_time desc limit #{skip}, #{size}")
    List<Cake> getCakesByCategoryId(@Param("categoryId")Long categoryId, @Param("skip") Integer skip,  @Param("size") Integer size);

    /**
     * 根据分类ID进行蛋糕数量的统计
     * @param categoryId    分类ID
     * @return  分类下蛋糕数量
     */
    @Select("select count(*) from cake where category_id = #{categoryId}")
    int countCakesByCategoryId(@Param("categoryId")Long categoryId);

    /**
     * 保存蛋糕信息
     * @param cake  蛋糕信息
     */
    @Insert("insert into cake(category_id, name, level, price, small_img, create_time, update_time) " +
            "value (#{cake.categoryId}, #{cake.name}, #{cake.level}, #{cake.price}, #{cake.smallImg}, " +
            "#{cake.createTime}, #{cake.updateTime})")
    void addCake(@Param("cake") Cake cake);

    /**
     * 查询蛋糕图片信息
     * @param id    蛋糕ID
     * @return  只包含图片的蛋糕实体
     */
    @Select("select small_img smallImg from cake where id = #{id} for update")
    Cake getImg(@Param("id")Long id);

}
